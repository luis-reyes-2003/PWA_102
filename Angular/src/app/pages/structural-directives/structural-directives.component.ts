import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-structural-directives',
  imports: [],
  templateUrl: './structural-directives.component.html',
})
export class StructuralDirectivesComponent {

  //if-else
  isVisible = signal(true);

  toggleVisibility() {
    this.isVisible.update(v => !v)
  }

  //swith
  viewMode = signal<'none' | 'list' | 'grid'>('none');

  setViewMode(mode: 'none' | 'list' | 'grid') {
    this.viewMode.set(mode);
  }

  //for
  users = signal([
    {id: 1, name: 'Alice', role: 'admin'},
    {id: 2, name: 'Bob', role: 'user'},
    {id: 3, name: 'Charlie', role: 'user'},
  ]);

}
