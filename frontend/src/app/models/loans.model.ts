export interface Loans {
  id: number,
  livroId: number,
  usuarioId: string,
  dataEmprestimo: Date,
  dataPrevDevolucao: Date,
  dataDevolucao: Date,
  observacoes: string,
  status: number
}