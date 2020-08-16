using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace RosabellaCosmetics.Business.ActionResult
{
    public class ActionResult
    {
        public bool IsSucceed { get; private set; }
        public string[] FailureResult { get; private set; }

        public static ActionResult Failure(params string[] failureResult)
        {
            var actionResult = new ActionResult();
            Failure(actionResult, failureResult);
            return actionResult;
        }

        public static ActionResult Succeed()
        {
            var result = new ActionResult();
            Succeed(result);
            return result;
        }

        protected static void Succeed(ActionResult result)
        {
            result.IsSucceed = true;
            result.FailureResult = new string[0];
        }

        protected static void Failure(ActionResult result, params string[] failureResult)
        {
            Contract.Requires(failureResult != null);
            Contract.Requires(failureResult.Any());
            result.IsSucceed = false;
            result.FailureResult = failureResult;
        }
    }

    public class ActionResult<T> : ActionResult
    {
        public T Data { get; set; }
        public new static ActionResult<T> Failure(params string[] failureResult)
        {
            var result = new ActionResult<T>();
            Failure(result, failureResult);
            return result;
        }

        public static ActionResult<T> Succeed(T data)
        {
            var result = new ActionResult<T>() { Data = data };
            Succeed(result);
            return result;
        }
    }
}
