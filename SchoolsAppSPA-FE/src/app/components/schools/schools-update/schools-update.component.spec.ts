import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SchoolsUpdateComponent } from './schools-update.component';

describe('SchoolsUpdateComponent', () => {
  let component: SchoolsUpdateComponent;
  let fixture: ComponentFixture<SchoolsUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SchoolsUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SchoolsUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
