using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace apiProdutos2.Infra
{
    public class LogUtils
    {
        public static object MsgErro(string nome, int id)
        {
            var erro = new { mensagem = $"{nome} com ID {id} não encontrado(a)" };
            return erro;
        }

        public static string MsgInsert(string nome, object objeto)
        {
            var erro = $"\n🆙 {nome} adicionado(a):\n{JsonSerializer.Serialize(objeto)}";
            return erro;
        }
        public static string MsgGet(string nome, object objeto)
        {
            var erro = $"\n✅ {nome} encontrado(a):\n{JsonSerializer.Serialize(objeto)}";
            return erro;
        }
        public static string MsgUpdate(string nome, object objeto)
        {
            var erro = $"\n🔄️ {nome} atualizado(a):\n{JsonSerializer.Serialize(objeto)}";
            return erro;
        }
        public static string MsgDelete(string nome, object objeto)
        {
            var erro = $"\n❌ {nome} deletado(a):\n{JsonSerializer.Serialize(objeto)}";
            return erro;
        }
    }
}