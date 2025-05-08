import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BordercrossingComponent } from './bordercrossing.component';

describe('BordercrossingComponent', () => {
  let component: BordercrossingComponent;
  let fixture: ComponentFixture<BordercrossingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BordercrossingComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BordercrossingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
