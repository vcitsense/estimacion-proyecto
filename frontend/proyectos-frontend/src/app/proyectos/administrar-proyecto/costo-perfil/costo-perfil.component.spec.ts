import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CostoPerfilComponent } from './costo-perfil.component';

describe('CostoPerfilComponent', () => {
  let component: CostoPerfilComponent;
  let fixture: ComponentFixture<CostoPerfilComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CostoPerfilComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CostoPerfilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
