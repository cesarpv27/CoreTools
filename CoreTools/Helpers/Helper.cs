using CoreTools.Extensions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExThrower = CoreTools.Throws.ExceptionThrower;

namespace CoreTools.Helpers
{
    public class Helper
    {
        #region Sync & Async

        public static async Task RunAsAsync(Action action)
        {
            await Task.Run(action);
        }

        public static TOut RunAsSync<TIn, TOut>(TIn _fIn, Func<TIn, Task<TOut>> func)
        {
            Task<TOut> task = Task.Run(async () => await func(_fIn));
            return task.WaitAndUnwrapException();
        }

        public static TOut RunAsSync<TIn1, TIn2, TOut>(TIn1 param1, TIn2 param2, Func<TIn1, TIn2, Task<TOut>> func)
        {
            Task<TOut> task = Task.Run(async () => await func(param1, param2));
            return task.WaitAndUnwrapException();
        }

        public static int ExecuteParallelForEach<FTIn1, FTIn3, FTOut>(Func<FTIn1, CancellationToken, FTIn3, FTOut> threadSafeFunc,
            IEnumerable<FTIn1> entities,
            FTIn3 funcParam3,
            Func<FTOut, bool> validateResponseFunc,
            CancellationToken funcCancellationToken = default,
            ParallelOptions parallelOptions = null)
        {
            if (parallelOptions == null)
                parallelOptions = new ParallelOptions();

            int successExecutions = 0;

            Parallel.ForEach<FTIn1, int>(entities, parallelOptions, () => 0, (ent, loop, subtotal) =>
            {
                if (validateResponseFunc(threadSafeFunc(ent, funcCancellationToken, funcParam3)))
                    subtotal++;

                return subtotal;
            },
            (finalResult) => Interlocked.Add(ref successExecutions, finalResult)
            );

            return successExecutions;
        }

        #endregion

        public static Dictionary<string, T> GetEnumNamesValues<T>() where T : System.Enum
        {
            if (typeof(T).IsEnum)
            {
                var names = Enum.GetNames(typeof(T));
                var _dictionary = new Dictionary<string, T>(names.Length);

                foreach (var _name in names)
                    _dictionary.Add(_name, (T)Enum.Parse(typeof(T), _name));

                return _dictionary;
            }

            return null;
        }

        public static HttpResponseMessage CreateHttpResponseMessage(HttpStatusCode httpStatusCode, string reasonPhrase = null)
        {
            return new HttpResponseMessage(httpStatusCode)
            {
                ReasonPhrase = reasonPhrase
            };
        }

        public static bool EnumContains<Enu>(int value) where Enu : Enum
        {
            return Enum.IsDefined(typeof(Enu), value);
        }

        public static int ConvertToInt(HttpStatusCode httpStatusCode)
        {
            return (int)httpStatusCode;
        }

        public static Dictionary<string, string> GetNameValueProperties<T>(T obj, PropertyInfo[] objProperties)
        {
            ExThrower.ST_ThrowIfArgumentIsNull(obj, nameof(obj), $"'{nameof(obj)}' is null");
            ExThrower.ST_ThrowIfArgumentIsNull(objProperties, nameof(objProperties), $"'{nameof(objProperties)}' is null");

            if (objProperties.Length == 0)
                ExThrower.ST_ThrowArgumentException(nameof(objProperties), "No properties found");

            var nameValueProperties = new Dictionary<string, string>(objProperties.Length);
            foreach (PropertyInfo _prop in objProperties)
                try
                {
                    nameValueProperties.Add(_prop.Name, _prop.GetValue(obj).ToString());
                }
                catch
                {
                }

            return nameValueProperties;
        }
    }
}
