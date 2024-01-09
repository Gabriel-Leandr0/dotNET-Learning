import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
})
export class EventosComponent implements OnInit {
  public eventos: any;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void {
    this.http.get('https://localhost:5001/api/eventos')
    this.eventos = [
      {
        EventoId: 1,
        Tema: 'Angular 11 e .NET 5',
        Local: 'Belo Horizonte',
      },
      {
        EventoId: 2,
        Tema: 'Angular e Suas Novidades',
        Local: 'São Paulo',
      },
      {
        EventoId: 3,
        Tema: 'Angular e Suas Novidades',
        Local: 'Rio de Janeiro',
      },
    ];
  }
}
