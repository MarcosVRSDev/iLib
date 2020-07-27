import { NbMenuItem } from '@nebular/theme';

export const MENU_ITEMS: NbMenuItem[] = [
  {
    title: 'Home',
    icon: 'home-outline',
    link: '/pages/home',
    home: true,
  },
  {
    title: 'Gerenciamento',
    icon: 'settings-outline',
    children: [
      {
        title: 'Cadastrar Livro',
        link: '/pages/create-book',
      },
      {
        title: 'Editar Livros',
        link: '/pages/books',
      },
      {
        title: 'Empréstimos',
        link: '/pages/loans',
      },
      {
        title: 'Histórico',
        link: '/pages/loans-hist',
      }
    ],
  },
  {
    title: 'FEATURES',
    group: true,
  },
  {
    title: 'Auth',
    icon: 'lock-outline',
    children: [
      {
        title: 'Login',
        link: '/auth/login',
      }
    ],
  },
];
