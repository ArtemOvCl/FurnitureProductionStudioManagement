import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FurnitureDetailsComponent } from './furniture-details.component';

describe('FurnitureDetailsComponent', () => {
  let component: FurnitureDetailsComponent;
  let fixture: ComponentFixture<FurnitureDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FurnitureDetailsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FurnitureDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
