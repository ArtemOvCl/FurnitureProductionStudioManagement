import { FieldErrors } from "./field-errors";

export interface ErrorResponse {
    errors?: FieldErrors;
    message?: string;
  }