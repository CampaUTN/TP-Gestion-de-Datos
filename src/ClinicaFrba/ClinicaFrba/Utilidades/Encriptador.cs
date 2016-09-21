using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ClinicaFrba {
    /// <summary>  Clase destinada a las operaciones de encriptación de contraseñas </summary>
    public static class Encriptador {
        /// <summary> Función de encriptación en <paramref name="SHA256"/> </summary>
        /// <param name="str"> El string a encriptar </param>
        /// <example><code> char[] hash = Encriptador.Encriptar("qwerty"); </code></example>
        /// <returns> Devuelve un string de 32 caracteres que contiene el hash encriptado </returns>
        /// <exception cref="DecoderFallbackException"> Al ocurrir un error en la codificación por el sistema operativo </exception>
        public static char[] Encriptar(string str) {
            byte[] hash = { 0 };
            using (var sha = SHA256.Create()) {
                try {
                    hash = sha.ComputeHash(Encoding.Default.GetBytes(str));
                } catch (ArgumentNullException) {
                    hash = sha.ComputeHash(Encoding.Default.GetBytes(""));
                } catch (DecoderFallbackException) {
                    throw;
                }
                // ObjectDisposedException imposible debido al using
                return Encoding.Default.GetString(hash).ToCharArray();
            }
        }
    }
}
