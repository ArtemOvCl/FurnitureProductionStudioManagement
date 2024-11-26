import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FilterFieldComponent } from './filter-field.component';

describe('FilterFieldComponent', () => {
  let component: FilterFieldComponent;
  let fixture: ComponentFixture<FilterFieldComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FilterFieldComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FilterFieldComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
