import { NbMenuItem } from '@nebular/theme';

export const MENU_ITEMS: NbMenuItem[] = [
  {
    title: 'Home',
    icon: 'home-outline',
    link: '/pages/home',
    home: true,
  },
  {
    title: 'Meus empréstimos',
    icon: 'archive-outline',
    children: [
      {
        title: 'Empréstimos',
        link: '/pages/',
      },
    ]
  },
  {
    title: 'Gerenciamento',
    icon: 'settings-outline',
    children: [
      {
        title: 'Livros',
        icon: 'book-outline',
        children: [
          {
            title: 'Cadastrar Livro',
            link: '/pages/create-book',
          },
          {
            title: 'Editar Livros',
            link: '/pages/books',
          },
        ],
      },
      {
        title: 'Empréstimos',
        icon: 'calendar-outline',
        children: [
          {
            title: 'Empréstimos',
            link: '/pages/loans',
          },
          {
            title: 'Histórico',
            link: '/pages/loans-hist',
          }
        ]
      },
    ],
  },
];
