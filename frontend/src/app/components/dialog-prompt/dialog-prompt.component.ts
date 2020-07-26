import { Component, Input } from '@angular/core';
import { NbDialogRef } from '@nebular/theme';

@Component({
  selector: 'ngx-dialog-prompt',
  templateUrl: 'dialog-prompt.component.html',
  styleUrls: ['dialog-prompt.component.scss'],
})
export class DialogPromptComponent {

  @Input() title: string;
  @Input() description: string;

  constructor(private ref: NbDialogRef<DialogPromptComponent>) { }

  cancel() {
    this.ref.close();
  }

  submit() {
      this.ref.close(true);
  }
}
