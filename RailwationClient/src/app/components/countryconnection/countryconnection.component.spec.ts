import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CountryconnectionComponent } from './countryconnection.component';

describe('CountryconnectionComponent', () => {
  let component: CountryconnectionComponent;
  let fixture: ComponentFixture<CountryconnectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CountryconnectionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CountryconnectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
