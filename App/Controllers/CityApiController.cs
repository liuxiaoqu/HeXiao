﻿using System;
using System.Collections.Generic;
using System.Linq;
 
using System.Text;
using System.EnterpriseServices;
using System.Configuration;
using Models;
using Common;
using Langben.DAL;
using Langben.BLL;
using System.Web.Http;
using Langben.App.Models;

namespace Langben.App.Controllers
{
    /// <summary>
    /// 缴纳地
    /// </summary>
    public class CityApiController : BaseApiController
    {

        /// <summary>
        /// 根据ID获取数据模型
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public City Get(string id)
        {
            City item = m_BLL.GetById(id);
            return item;
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public Common.ClientResult.Result Post([FromBody]City entity)
        {

            Common.ClientResult.Result result = new Common.ClientResult.Result();
            if (entity != null && ModelState.IsValid)
            {
                string currentPerson = GetCurrentPerson();
                entity.CreateTime = DateTime.Now; 
                entity.CreatePerson = currentPerson;
                entity.Vertion = GetVersion();
                entity.Id = Result.GetNewId();
                string returnValue = string.Empty;
                if (m_BLL.Create(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，缴纳地的信息的Id为" + entity.Id, "缴纳地"
                        );//写入日志 
                    result.Code = Common.ClientCode.Succeed;
                    result.Message = Suggestion.InsertSucceed;
                    return result; //提示创建成功
                }
                else
                {
                    if (validationErrors != null && validationErrors.Count > 0)
                    {
                        validationErrors.All(a =>
                        {
                            returnValue += a.ErrorMessage;
                            return true;
                        });
                    }
                    LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，缴纳地的信息，" + returnValue, "缴纳地"
                        );//写入日志                      
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.InsertFail + returnValue;
                    return result; //提示插入失败
                }
            }

            result.Code = Common.ClientCode.FindNull;
            result.Message = Suggestion.InsertFail + "，请核对输入的数据的格式"; //提示输入的数据的格式不对 
            return result;
        }

        // PUT api/<controller>/5
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>  
        public Common.ClientResult.Result Put([FromBody]City entity)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            if (entity != null && ModelState.IsValid)
            {   //数据校验

                string currentPerson = GetCurrentPerson();
                entity.UpdateTime = DateTime.Now;
                entity.UpdatePerson = currentPerson;

                string returnValue = string.Empty;
                if (m_BLL.Edit(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，缴纳地信息的Id为" + entity.Id, "缴纳地"
                        );//写入日志                   
                    result.Code = Common.ClientCode.Succeed;
                    result.Message = Suggestion.UpdateSucceed;
                    return result; //提示更新成功 
                }
                else
                {
                    if (validationErrors != null && validationErrors.Count > 0)
                    {
                        validationErrors.All(a =>
                        {
                            returnValue += a.ErrorMessage;
                            return true;
                        });
                    }
                    LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，缴纳地信息的Id为" + entity.Id + "," + returnValue, "缴纳地"
                        );//写入日志   
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.UpdateFail + returnValue;
                    return result; //提示更新失败
                }
            }
            result.Code = Common.ClientCode.FindNull;
            result.Message = Suggestion.UpdateFail + "请核对输入的数据的格式";
            return result; //提示输入的数据的格式不对         
        }

        // DELETE api/<controller>/5
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>  
        /// 
        [HttpDelete]
        public Common.ClientResult.Result Delete(string id)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();

            string returnValue = string.Empty;


            if (m_BLL.Delete(ref validationErrors, id))
            {
                LogClassModels.WriteServiceLog(Suggestion.DeleteSucceed + "，信息的Id为" + string.Join(",", id), "消息"
                    );//删除成功，写入日志
                result.Code = Common.ClientCode.Succeed;
                result.Message = Suggestion.DeleteSucceed;
            }
            else
            {
                if (validationErrors != null && validationErrors.Count > 0)
                {
                    validationErrors.All(a =>
                    {
                        returnValue += a.ErrorMessage;
                        return true;
                    });
                }
                LogClassModels.WriteServiceLog(Suggestion.DeleteFail + "，信息的Id为" + string.Join(",", id) + "," + returnValue, "消息"
                    );//删除失败，写入日志
                result.Code = Common.ClientCode.Fail;
                result.Message = Suggestion.DeleteFail + returnValue;

            }
            return result;
        }

        IBLL.ICityBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public CityApiController()
            : this(new CityBLL()) { }

        public CityApiController(CityBLL bll)
        {
            m_BLL = bll;
        }
    }
}


