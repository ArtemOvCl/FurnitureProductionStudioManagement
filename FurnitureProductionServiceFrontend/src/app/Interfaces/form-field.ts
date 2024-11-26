export interface FormField {
    key: string;
    label: string; 
    type: 'input' | 'select' | 'file';
    options?: { value: any; label: string }[]; 
    required?: boolean;
  }