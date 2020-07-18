using System;

namespace ILib.Core.Dados
{
    public interface IRepositorio<T> : IDisposable where T : Entidade
    {
    }
}
