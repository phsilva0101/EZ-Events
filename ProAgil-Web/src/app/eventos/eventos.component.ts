import { Component, OnInit } from '@angular/core';
import { EventosService } from '../_services/eventos.service';
import { Event } from '../_models/Event';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ptBrLocale, defineLocale } from 'ngx-bootstrap/chronos';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';

defineLocale('pt-br', ptBrLocale)



@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  
  eventos!: Event[];
  eventosFiltrados!: Event[];
  
  imagemLargura = 50;
  imagemMargem = 2;

  form!: FormGroup
  
  _filtroLista = '';
  
  constructor(
    private eventosService: EventosService,
    private fb: FormBuilder,
    private locale: BsLocaleService
    
    ) { 
      this.locale.use('pt-br')
    }

  ngOnInit() {
    this.validation()
    this.getEvents()
  }

  //Filtro de eventos
  get filtroLista(): string {
    return this._filtroLista;
  }
  set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;    
  }
  
  filtrarEventos(filtrarPor: string): Event[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      evento => evento.theme.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      );
    }
    
    //------------------------------------------------------------------------------
    // Validação de formulários

    validation(){
      this.form = this.fb.group({
        local: ['', [Validators.required,Validators.minLength(3), Validators.maxLength(30)]],
        theme: ['', Validators.required], 
        amountOfPeople: ['', [Validators.required, Validators.min(10), Validators.max(120000)]], 
        date: ['', Validators.required], 
        imagemURL: ['', Validators.required], 
        phone: ['', Validators.required], 
        email: ['',[ Validators.required, Validators.email]],
      })
    }
    
    //---------------------------------------------------------------
    // Modal
    
    openModal(template: any){
      template.show();
    }
    
    
    getEvents(){
      this.eventosService.getAllEventos().subscribe(
        (_eventos) => {
          this.eventos = _eventos
        },
        error => {
          console.log(error)
        }
        )
      }
      
    }
    