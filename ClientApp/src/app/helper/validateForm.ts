import { FormGroup, FormControl } from "@angular/forms";

export default class ValidateForm {

  static validateAllFields(formGroup: FormGroup) {
    debugger
    Object.keys(formGroup.controls).forEach(field => {
      const control = formGroup.get(field);
      if (control instanceof FormControl) {
        control.markAsDirty({ onlySelf: true })
      } else if (control instanceof FormGroup) {
        this.validateAllFields(control);
      }
    })
  }
}
