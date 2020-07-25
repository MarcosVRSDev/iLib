export interface Books {
  Id: number,
  Codigo: string,
  FotoUrl: string,
  Titulo: string,
  Autor: string,
  Editora: string,
  Emprestado: boolean,
  Estado: number,
  Observacoes: string //Sinopse do livro ou coisa do tipo
}