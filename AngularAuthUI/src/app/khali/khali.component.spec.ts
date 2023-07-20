import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KhaliComponent } from './khali.component';

describe('KhaliComponent', () => {
  let component: KhaliComponent;
  let fixture: ComponentFixture<KhaliComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KhaliComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(KhaliComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
