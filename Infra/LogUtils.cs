using System.Diagnostics;
using System.Text.Json;

namespace MenuOn.Infra
{
    public class LogUtils
    {
        private static string GetNome()
        {
            var stackTrace = new StackTrace();
            var frame = stackTrace.GetFrame(2);
            var method = frame?.GetMethod();
            var declaringType = method?.DeclaringType;
            return declaringType?.Name.Replace("sController", "") ?? "Desconhecido";
        }

        public static object MsgErro(int id, string nome = null)
        {
            nome ??= GetNome();
            var erro = new { mensagem = $"{nome} com ID {id} não encontrado(a)" };
            return erro;
        }

        public static string MsgInsert(object objeto)
        {
            var nome = GetNome();
            var erro = $"\n🆙 {nome} adicionado(a):\n{JsonSerializer.Serialize(objeto)}";
            return erro;
        }
        public static string MsgGet(object objeto)
        {
            var nome = GetNome();
            var erro = $"\n✅ {nome} encontrado(a):\n{JsonSerializer.Serialize(objeto)}";
            return erro;
        }
        public static string MsgUpdate(object objeto)
        {
            var nome = GetNome();
            var erro = $"\n🔄️ {nome} atualizado(a):\n{JsonSerializer.Serialize(objeto)}";
            return erro;
        }
        public static string MsgDelete(object objeto)
        {
            var nome = GetNome();
            var erro = $"\n❌ {nome} deletado(a):\n{JsonSerializer.Serialize(objeto)}";
            return erro;
        }
    }
}