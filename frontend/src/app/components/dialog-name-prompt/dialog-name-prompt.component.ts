import { Component } from '@angular/core';
import { NbDialogRef } from '@nebular/theme';
import { NbToastrService } from '@nebular/theme';
import { Router } from '@angular/router';

@Component({
  selector: 'ngx-dialog-name-prompt',
  templateUrl: 'dialog-name-prompt.component.html',
  styleUrls: ['dialog-name-prompt.component.scss'],
})
export class DialogNamePromptComponent {

  constructor(protected ref: NbDialogRef<DialogNamePromptComponent>,
    private toastrService: NbToastrService,
    private router: Router) { }

  showToast(status) {
    this.toastrService.show("Sua solicitação foi criada com sucesso!",
      `Solicitação de emprestímo`, { status });
  }

  cancel() {
    this.ref.close();
  }

  submit(status) {
    this.ref.close();
    this.showToast(status);
    this.router.navigateByUrl('/');
  }
}
