import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FurnituresPageComponent } from './furnitures-page.component';

describe('FurnituresPageComponent', () => {
  let component: FurnituresPageComponent;
  let fixture: ComponentFixture<FurnituresPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FurnituresPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FurnituresPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
