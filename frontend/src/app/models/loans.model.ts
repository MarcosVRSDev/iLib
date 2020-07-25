export interface Loans {
  Id: number,
  LivroId: number,
  UsuarioId: string,
  DataEmprestimo: Date,
  DataPrevDevolucao: Date,
  DataDevolucao: Date,
  Observacoes: string,
  Status: number
}