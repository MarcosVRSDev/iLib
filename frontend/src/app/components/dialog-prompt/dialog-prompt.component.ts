import { Component } from '@angular/core';
import { NbDialogRef } from '@nebular/theme';
import { NbToastrService } from '@nebular/theme';
import { Router } from '@angular/router';

@Component({
  selector: 'ngx-dialog-prompt',
  templateUrl: 'dialog-prompt.component.html',
  styleUrls: ['dialog-prompt.component.scss'],
})
export class DialogPromptComponent {

  constructor(protected ref: NbDialogRef<DialogPromptComponent>,
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
