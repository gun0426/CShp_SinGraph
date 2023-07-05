using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Text;

namespace Chart_Project
{
    /// <summary>
    /// 함수 컴파일러
    /// </summary>
    public static class FunctionCompiler
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////// Field
        ////////////////////////////////////////////////////////////////////////////////////////// Private

        #region Field

        /// <summary>
        /// 클래스 평가 문자열
        /// </summary>
        private const string EVAL_CLASS = @"
using {1};
public class Eval
{{
    public static double e  {{ get {{ return System.Math.E;  }}  }}
    public static double pi {{ get {{ return System.Math.PI; }}  }}
    public static double abs  (double x)           {{ return System.Math.Abs(x);      }}
    public static double acos (double x)           {{ return System.Math.Acos(x);     }}
    public static double asin (double x)           {{ return System.Math.Asin(x);     }}
    public static double atan (double x)           {{ return System.Math.Atan(x);     }}
    public static double atan2(double x, double y) {{ return System.Math.Atan2(x, y); }}
    public static double ceil (double x)           {{ return System.Math.Ceiling(x);  }}
    public static double cos  (double x)           {{ return System.Math.Cos(x);      }}
    public static double cosh (double x)           {{ return System.Math.Cosh(x);     }}
    public static double exp  (double x)           {{ return System.Math.Exp(x);      }}
    public static double floor(double x)           {{ return System.Math.Floor(x);    }}
    public static double log  (double x)           {{ return System.Math.Log(x);      }}
    public static double log2 (double x)           {{ return System.Math.Log(x, 2.0); }}
    public static double log10(double x)           {{ return System.Math.Log10(x);    }}
    public static double max  (double x, double y) {{ return System.Math.Max(x, y);   }}
    public static double min  (double x, double y) {{ return System.Math.Min(x, y);   }}
    public static double pow  (double x, double y) {{ return System.Math.Pow(x, y);   }}
    public static double round(double x)           {{ return System.Math.Round(x);    }}
    public static double sign (double x)           {{ return System.Math.Sign(x);     }}
    public static double sin  (double x)           {{ return System.Math.Sin(x);      }}
    public static double sinh (double x)           {{ return System.Math.Sinh(x);     }}
    public static double sqrt (double x)           {{ return System.Math.Sqrt(x);     }}
    public static double tan  (double x)           {{ return System.Math.Tan(x);      }}
    public static double tanh (double x)           {{ return System.Math.Tanh(x);     }}
    public static double __eval(params double[] __X)
    {{
        double x = __X[0];
        double y = __X[1];
        return {0};
    }}
    public static {2} __get()
    {{
        return __eval;
    }}
}}";

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Method
        ////////////////////////////////////////////////////////////////////////////////////////// Static
        //////////////////////////////////////////////////////////////////////////////// Public

        #region 컴파일하기 - Compile(sourceCode)

        /// <summary>
        /// 컴파일하기
        /// </summary>
        /// <param name="sourceCode">소스 코드</param>
        /// <returns>렌더러 대리자</returns>
        public static RendererDelegate Compile(string sourceCode)
        {
            sourceCode = sourceCode.Trim().ToLower();

            if(sourceCode.Contains(";"))
            {
                throw new Exception("Function string cannot contain semicolon");
            }

            string evalClass = string.Format(EVAL_CLASS, sourceCode, typeof(CompilerDelegate).Namespace, typeof(CompilerDelegate).Name);

            CSharpCodeProvider provider   = new CSharpCodeProvider();
            CompilerParameters parameters = new CompilerParameters();

            parameters.CompilerOptions  = "/t:library";
            parameters.GenerateInMemory = true;

            parameters.ReferencedAssemblies.Add("mscorlib.dll");
            parameters.ReferencedAssemblies.Add("System.dll");
            parameters.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);

            CompilerResults results = provider.CompileAssemblyFromSource(parameters, evalClass);

            if(results.Errors.HasErrors)
            {
                StringBuilder stringBuilder = new StringBuilder();

                if(results.Errors.Count == 1)
                {
                    stringBuilder.Append("Compilation error :\n");
                }
                else
                {
                    stringBuilder.AppendFormat("{0} Compilation errors :\n", results.Errors.Count);
                }

                foreach(CompilerError error in results.Errors)
                {
                    stringBuilder.Append(error.ErrorText);
                    stringBuilder.Append("\n");
                }

                stringBuilder.Append
                (
                    "\nSupported math functions are:\n" +
                    "e, pi, abs(), acos(), asin(), atan(), atan2(), ceil(), cos(), cosh(), " +
                    "exp(), floor(), log(), log2(), log10(), max(), min(), pow(), " +
                    "round(), sign(), sin(), sinh(), sqrt(), tan(), tanh()\n"
                );

                throw new Exception(stringBuilder.ToString());
            }

            MethodInfo methodInfo = results.CompiledAssembly.GetType("Eval").GetMethod("__get");

            CompilerDelegate compilerDelegate = (CompilerDelegate)methodInfo.Invoke(null, null);

            RendererDelegate redererDelegate = delegate(double X, double Y)
            {
                return compilerDelegate(X, Y);
            };

            return redererDelegate;
        }

        #endregion
    }
}