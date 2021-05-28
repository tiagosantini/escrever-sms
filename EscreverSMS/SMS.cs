using System;
using System.Collections.Generic;
using System.IO;


namespace EscreverSMS
{
    public class SMS : Dicionario
    {
        private string mensagem;

        public SMS(string input)
        {
            mensagem = input;
            ValidarTamanhoDaMensagem();
        }

        /// <summary>
        /// Dada uma mensagem de texto limitada a 255 caracteres, retorna a seqüência de números equivalente em teclado de celular. Uma pausa, para ser possível obter duas letras referenciadas pelo mesmo número, é indicada como "_"
        /// </summary>
        /// <returns>Sequência de números equivalente em teclado de celular</returns>
        public string SequenciaNumerica()
        {
            string strNumerosResultado = "";
            string saidaAtual;
            string proximaSaida;

            for (int i = 0; i < mensagem.Length; i++)
            {
                strNumerosResultado += EscreverNumero(mensagem.Substring(i, 1));

                if (i + 1 < mensagem.Length)
                {
                    saidaAtual = EscreverNumero(mensagem.Substring(i, 1)).Substring(0, 1);
                    proximaSaida = EscreverNumero(mensagem.Substring(i + 1, 1)).Substring(0, 1);

                    if (saidaAtual == proximaSaida)
                        strNumerosResultado += "_";
                }
            }

            return strNumerosResultado;
        }

        private string EscreverNumero(string letra)
        {
            string numero;
            letra = letra.ToUpper();

            if (numeros.ContainsKey(letra))
                numero = numeros[letra];
            else
                numero = letra;

            return numero;
        }

        private void ValidarTamanhoDaMensagem()
        {
            if (mensagem.Length > 255)
                throw new ArgumentOutOfRangeException("A mensagem deve ter no máximo 255 caracteres!");
        }
    }
}
