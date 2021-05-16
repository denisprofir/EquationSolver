import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';
import { ListEquationDataSource, ListEquationItem } from './list-equation-datasource';

@Component({
  selector: 'app-list-equation',
  templateUrl: './list-equation.component.html',
  styleUrls: ['./list-equation.component.css']
})
export class ListEquationComponent {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatTable) table!: MatTable<ListEquationItem>;
  dataSource: ListEquationDataSource = new ListEquationDataSource([]);

  displayedColumns = ['coefficientA', 'coefficientB', 'coefficientC', 'discriminant', 'firstRoot', 'secondRoot', 'solvedAt'];

  constructor(private httpClient: HttpClient) {
    this.httpClient.get<ListEquationItem[]>('https://localhost:44349/equationsolver').subscribe(data => {
      this.dataSource.data = data;

      this.setupDataSource();
    });
  }

  private setupDataSource = () => {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
    this.table.dataSource = this.dataSource;
  }
}
