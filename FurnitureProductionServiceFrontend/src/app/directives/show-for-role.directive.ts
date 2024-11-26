import { Directive, Input, TemplateRef, ViewContainerRef } from '@angular/core';
import { AuthService } from '../Services/auth.service';

@Directive({
  selector: '[appShowForRole]',
  standalone: true
})
export class ShowForRoleDirective {
  @Input() set appShowForRole(roles: string[]) {
    const userRole = this.authService.getRole();
    console.log(userRole);

    if (userRole && roles.includes(userRole)) {

      this.viewContainer.createEmbeddedView(this.templateRef);
    } else {

      this.viewContainer.clear();
    }
  }

  constructor(
    private templateRef: TemplateRef<any>,
    private viewContainer: ViewContainerRef,
    private authService: AuthService
  ) {}
}
