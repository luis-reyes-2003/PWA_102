import { Routes } from '@angular/router';
import { HomepageComponent } from './pages/homepage/homepage.component';
import { CounterPageComponent } from './pages/counter-page/counter-page.component';
import { StructuralDirectivesComponent } from './pages/structural-directives/structural-directives.component';
import { AttributeDirectivesPageComponent } from './pages/attribute-directives_page/attribute-directives_page.component';
import { DataBindingPageComponent } from './pages/data-binding-page/data-binding-page.component';

export const routes: Routes = [
    {path: 'home', component: HomepageComponent},
    {path: 'counter', component: CounterPageComponent},
    {path: 'structural_directives', component: StructuralDirectivesComponent},
    {path: 'attribute_directives', component: AttributeDirectivesPageComponent},
    {path: 'data_binding', component: DataBindingPageComponent},
    {path: '**', redirectTo: 'home', pathMatch: 'full'}
];
