import type { AuditedEntityDto, EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { BookType } from './book-type.enum';
import type { Location } from './location.enum';

export interface BookDto extends AuditedEntityDto<string> {
  authorId?: string;
  authorName?: string;
  name?: string;
  type: BookType;
  publishDate?: string;
  physicalLocation: Location;
  description?: string;
  coverImage?: string;
  numberOfPage: number;
}

export interface BookLookupDto extends EntityDto<string> {
  name?: string;
}

export interface GetBookListDto extends PagedAndSortedResultRequestDto {
  filter?: string;
}
