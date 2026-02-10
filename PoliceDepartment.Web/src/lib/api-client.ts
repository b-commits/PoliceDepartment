import type {
  PoliceOfficer,
  CreateOfficerRequest,
  UpdateOfficerRequest,
  ApiError,
} from "@/types/officer";

const BASE_URL: string = "/api";

class ApiClientError extends Error {
  public status: number;
  public detail: string;

  constructor(error: ApiError) {
    super(error.title);
    this.name = "ApiClientError";
    this.status = error.status;
    this.detail = error.detail;
  }
}

async function request<T>(
  path: string,
  options?: RequestInit
): Promise<T> {
  const response: Response = await fetch(`${BASE_URL}${path}`, {
    ...options,
    headers: {
      "Content-Type": "application/json",
      ...options?.headers,
    },
  });

  if (!response.ok) {
    const text: string = await response.text();
    let error: ApiError;
    try {
      error = JSON.parse(text) as ApiError;
    } catch {
      error = {
        type: "UnknownError",
        title: text || `Request failed with status ${response.status}`,
        status: response.status,
        detail: text,
      };
    }
    throw new ApiClientError(error);
  }

  const text: string = await response.text();
  if (!text) {
    return undefined as T;
  }

  return JSON.parse(text) as T;
}

export async function getOfficers(): Promise<PoliceOfficer[]> {
  const data: PoliceOfficer[] | { $values: PoliceOfficer[] } =
    await request<PoliceOfficer[] | { $values: PoliceOfficer[] }>(
      "/PoliceOfficers"
    );

  if (Array.isArray(data)) {
    return data;
  }

  return data.$values ?? [];
}

export async function getOfficer(id: string): Promise<PoliceOfficer> {
  return request<PoliceOfficer>(`/PoliceOfficers/${id}`);
}

export async function createOfficer(
  data: CreateOfficerRequest
): Promise<PoliceOfficer> {
  return request<PoliceOfficer>("/PoliceOfficers", {
    method: "POST",
    body: JSON.stringify(data),
  });
}

export async function updateOfficer(
  id: string,
  data: UpdateOfficerRequest
): Promise<void> {
  return request<void>(`/PoliceOfficers/${id}`, {
    method: "PUT",
    body: JSON.stringify({ id, officer: data }),
  });
}

export async function deleteOfficer(id: string): Promise<void> {
  return request<void>(`/PoliceOfficers/${id}`, {
    method: "DELETE",
  });
}

export { ApiClientError };