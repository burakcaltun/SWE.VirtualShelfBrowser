import type { GetLendingListDto, LendingDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { ListResultDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { BookLookupDto } from '../books/models';

@Injectable({
  providedIn: 'root',
})
export class LendingService {
  apiName = 'Default';
  

  create = (input: LendingDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, LendingDto>({
      method: 'POST',
      url: '/api/app/lending',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/lending/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, LendingDto>({
      method: 'GET',
      url: `/api/app/lending/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getBookLookup = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, ListResultDto<BookLookupDto>>({
      method: 'GET',
      url: '/api/app/lending/book-lookup',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetLendingListDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<LendingDto>>({
      method: 'GET',
      url: '/api/app/lending',
      params: { filter: input.filter, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: LendingDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: `/api/app/lending/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
