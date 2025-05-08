import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CountrySidebarComponent } from './country-sidebar.component';

describe('CountrySidebarComponent', () => {
  let component: CountrySidebarComponent;
  let fixture: ComponentFixture<CountrySidebarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CountrySidebarComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CountrySidebarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
