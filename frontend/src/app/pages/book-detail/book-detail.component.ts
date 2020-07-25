import { Component } from '@angular/core';
import { NbDialogService } from '@nebular/theme';
import { DialogPromptComponent } from '../../components/dialog-prompt/dialog-prompt.component';

@Component({
  selector: 'ngx-book-detail',
  styleUrls: ['book-detail.component.scss'],
  templateUrl: './book-detail.component.html',
})
export class BookDetailComponent {
  constructor(private dialogService: NbDialogService) {
  }
  open() {
    this.dialogService.open(DialogPromptComponent);
  }
}
