import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SchoolsCreateComponent } from './components/schools/schools-create/schools-create.component';
import { SchoolsListComponent } from './components/schools/schools-list/schools-list.component';
import { SchoolsComponent } from './components/schools/schools/schools.component';
import { StudentsCreateComponent } from './components/students/students-create/students-create.component';
import { StudentsListComponent } from './components/students/students-list/students-list.component';
import { StudentsComponent } from './components/students/students/students.component';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SchoolsUpdateComponent } from './components/schools/schools-update/schools-update.component';

@NgModule({
  declarations: [
    AppComponent,
    SchoolsComponent,
    SchoolsCreateComponent,
    SchoolsListComponent,
    StudentsComponent,
    StudentsCreateComponent,
    StudentsListComponent,
    SchoolsUpdateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
