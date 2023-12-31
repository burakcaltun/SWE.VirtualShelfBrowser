import type { AuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetLendingListDto extends PagedAndSortedResultRequestDto {
  filter?: string;
}

export interface LendingDto extends AuditedEntityDto<string> {
  userId?: string;
  userName?: string;
  lenderId?: string;
  lenderName?: string;
  bookId?: string;
  bookName?: string;
  startDate?: string;
  endDate?: string;
}
