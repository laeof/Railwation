import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CityconnectionComponent } from './cityconnection.component';

describe('CityconnectionComponent', () => {
  let component: CityconnectionComponent;
  let fixture: ComponentFixture<CityconnectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CityconnectionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CityconnectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
