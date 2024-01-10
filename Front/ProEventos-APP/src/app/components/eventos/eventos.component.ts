import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
})
export class EventosComponent implements OnInit {
  public eventos: any = [];
  widthImg: number = 80;
  heightImg: number = 50;
  marginImg: number = 2;

  private _filtroLista: string = '';
  public eventosFiltrados: Evento[] = [];

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: { tema: string; local: string }) =>
        evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }



  exibirImagem: boolean = false;
  alterarImagem() {
    this.exibirImagem = !this.exibirImagem;
  }

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void {
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      (response) =>{
        this.eventos = response;
        this.eventosFiltrados = this.eventos;
        console.log(response)
      },
      (error) => console.log(error)
    );
  }
}

interface Evento {
  eventosId: number;
  tema: string;
  local: string;
  lote: string;
  qtdPessoas: number;
  dataEvento: string;
  imagemURL: string;

}