namespace ILib.Servicos.Emprestimos.Validadores.SelecaoPosStatus
{
    public interface IEmprestimoValidacaoSelecaoPorStatus : IEmprestimoValidacao<EmprestimoViewModel>
    {
        bool ValidarStatusEmprestimo(int statusEnum);
    }
}
