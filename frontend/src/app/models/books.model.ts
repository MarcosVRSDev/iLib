export interface Books {
  id: number,
  codigo: string,
  fotoUrl: string,
  titulo: string,
  autor: string,
  editora: string,
  emprestado: boolean,
  estado: number,
  observacoes: string //Sinopse do livro ou coisa do tipo
}