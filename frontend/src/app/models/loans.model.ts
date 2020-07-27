export interface Loans {
  id?: number,
  livroId: number,
  usuarioId: string,
  dataEmprestimo?: Date,
  dataPrevDevolucao?: Date,
  dataDevolucao?: Date,
  observacao?: string,
  status?: number
}