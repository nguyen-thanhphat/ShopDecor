import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditPamentMethodsComponent } from './add-edit-pament-methods.component';

describe('AddEditPamentMethodsComponent', () => {
  let component: AddEditPamentMethodsComponent;
  let fixture: ComponentFixture<AddEditPamentMethodsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditPamentMethodsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddEditPamentMethodsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
