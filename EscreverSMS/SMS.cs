using System;
using System.Collections.Generic;
using System.IO;


namespace EscreverSMS
{
    public class SMS
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
        public string Processar()
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
            string numero = "";

            switch (letra)
            {
                case "A": numero = "2"; break;
                case "B": numero = "22"; break;
                case "C": numero = "222"; break;
                case "D": numero = "3"; break;
                case "E": numero = "33"; break;
                case "F": numero = "333"; break;
                case "G": numero = "4"; break;
                case "H": numero = "44"; break;
                case "I": numero = "444"; break;
                case "J": numero = "5"; break;
                case "K": numero = "55"; break;
                case "L": numero = "555"; break;
                case "M": numero = "6"; break;
                case "N": numero = "66"; break;
                case "O": numero = "666"; break;
                case "P": numero = "7"; break;
                case "Q": numero = "77"; break;
                case "R": numero = "777"; break;
                case "S": numero = "7777"; break;
                case "T": numero = "8"; break;
                case "U": numero = "88"; break;
                case "V": numero = "888"; break;
                case "W": numero = "9"; break;
                case "X": numero = "99"; break;
                case "Y": numero = "999"; break;
                case "Z": numero = "9999"; break;
                case " ": numero = "0"; break;
                default: numero = letra; break;
            }

            return numero;
        }

        private void ValidarTamanhoDaMensagem()
        {
            if (mensagem.Length > 255)
                throw new ArgumentOutOfRangeException("A mensagem deve ter no máximo 255 caracteres!");
        }
    }
}
