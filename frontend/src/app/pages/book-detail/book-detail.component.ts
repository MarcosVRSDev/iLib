import { Component } from '@angular/core';
import { NbDialogService } from '@nebular/theme';
import { DialogNamePromptComponent } from './../../components/dialog-name-prompt/dialog-name-prompt.component';

@Component({
  selector: 'ngx-book-detail',
  styleUrls: ['book-detail.component.scss'],
  templateUrl: './book-detail.component.html',
})
export class BookDetailComponent {
  constructor(private dialogService: NbDialogService) {
  }
  open() {
    this.dialogService.open(DialogNamePromptComponent);
  }
}
