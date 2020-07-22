using FluentValidation.Results;

namespace ILib.Servicos.Livros.Validadores
{
    public interface ILivroValidacao<T>
        where T : LivroViewModel
    {
        ValidationResult Validar(T obj);
    }
}
