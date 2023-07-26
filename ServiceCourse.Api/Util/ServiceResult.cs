﻿using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ServiceCourse.Api.Util
{
   [DataContract]
    public class ServiceResult
    {
        /// <summary>
        /// Indica se a requisição foi realizado com sucesso (`true`) ou não (`false`).
        /// </summary>
        [DataMember]
        public bool Success { get; set; }

        [JsonIgnore]
        public Exception Error { get; set; }

        /// <summary>
        /// Mensagem de erro em caso de falha na requisição.
        /// </summary>
        [DataMember]
        public string ErrorMessage => Error?.Message;

        private ServiceResultErrorType _errorType = ServiceResultErrorType.NotSet;

        [DataMember]
        public ServiceResultErrorType ErrorType
        {
            get { return this._errorType; }
            set { this._errorType = value; }
        }


        public ServiceResult SetSuccess()
        {
            this.Success = true;
            this.Error = null;
            return this;
        }

        public ServiceResult SetError(Exception ex)
        {
            this.Success = false;
            this.Error = ex;
            if (ex is ApplicationException)
            {
                this.ErrorType = ServiceResultErrorType.Application;
            }
            else
            {
                this.ErrorType = ServiceResultErrorType.Exception;
            }
            return this;
        }

        public ServiceResult SetError(string errorMessage)
        {
            this.Success = false;
            this.SetError(new ApplicationException(errorMessage));
            return this;
        }

        public ServiceResult SetError(string errorMessage, params object[] parameters)
        {
            this.SetError(string.Format(errorMessage, parameters));
            return this;
        }

        public static ServiceResult GetSuccessResult()
        {
            var result = new ServiceResult();
            return result.SetSuccess();
        }

        public static ServiceResult GetErrorResult(string errorMessage)
        {
            var result = new ServiceResult();
            return result.SetError(errorMessage);
        }
    }

    [DataContract]
    public sealed class ServiceResult<T> : ServiceResult
    {
        /// <summary>
        /// Dados da entidade processada na requisição.
        /// </summary>
        [DataMember]
        public T Result { get; set; }

        /// <summary>
        /// Lista de dados da entidade processada na requisição (se aplicável).
        /// </summary>
        [DataMember]
        public List<T> ResultList { get; set; }

        public new ServiceResult<T> SetSuccess()
        {
            base.SetSuccess();
            Result = default;
            ResultList = null;
            return this;
        }

        public ServiceResult<T> SetSuccess(T result)
        {
            base.SetSuccess();
            Result = result;
            ResultList = null;
            return this;
        }

        public ServiceResult<T> SetSuccess(List<T> resultList)
        {
            base.SetSuccess();
            Result = default;
            ResultList = resultList;
            return this;
        }

        public new ServiceResult<T> SetError(Exception ex)
        {
            base.SetError(ex);
            Result = default;
            ResultList = null;
            return this;
        }

        public new ServiceResult<T> SetError(string errorMessage)
        {
            base.SetError(errorMessage);
            Result = default;
            ResultList = null;
            return this;
        }

        public new ServiceResult<T> SetError(string errorMessage, params object[] parameters)
        {
            base.SetError(errorMessage, parameters);
            Result = default;
            ResultList = null;
            return this;
        }

        public ServiceResult<T> GetSuccessResult(T result)
        {
            var returnResult = new ServiceResult<T>();
            return returnResult.SetSuccess(result);
        }

        public ServiceResult<T> GetSuccessResult(List<T> resultList)
        {
            var returnResult = new ServiceResult<T>();
            return returnResult.SetSuccess(resultList);
        }
    }

    /// <summary>
    /// Define o tipo de erro:
    /// - `0 - NotSet`: Não definido.
    /// - `1 - Exception`: Erro interno desconhecido.
    /// - `2 - Application`: Erro conhecido tratado pela aplicação.
    /// </summary>
    public enum ServiceResultErrorType
    {
        NotSet,
        Exception,
        Application
    }
}
