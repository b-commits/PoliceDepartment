import { describe, it, expect, vi, beforeEach } from "vitest";
import { renderHook, waitFor } from "@testing-library/react";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import type { ReactNode } from "react";
import { useOfficers } from "@/hooks/useOfficers";
import type { PoliceOfficer } from "@/types/officer";

const mockOfficers: PoliceOfficer[] = [
  {
    id: "1",
    firstName: "John",
    lastName: "Smith",
    badgeNumber: { value: "#-123-456-789" },
    birthDate: { value: "1985-03-15" },
    created: "2024-01-01T00:00:00Z",
    modified: "2024-01-01T00:00:00Z",
  },
];

vi.mock("@/lib/api-client", () => ({
  getOfficers: vi.fn((): Promise<PoliceOfficer[]> => Promise.resolve(mockOfficers)),
}));

function createWrapper(): ({ children }: { children: ReactNode }) => ReactNode {
  const queryClient: QueryClient = new QueryClient({
    defaultOptions: {
      queries: { retry: false },
    },
  });

  return function Wrapper({ children }: { children: ReactNode }): ReactNode {
    return (
      <QueryClientProvider client={queryClient}>
        {children}
      </QueryClientProvider>
    );
  };
}

describe("useOfficers", () => {
  beforeEach(() => {
    vi.clearAllMocks();
  });

  it("fetches officers successfully", async () => {
    const { result } = renderHook(() => useOfficers(), {
      wrapper: createWrapper(),
    });

    await waitFor(() => {
      expect(result.current.isSuccess).toBe(true);
    });

    expect(result.current.data).toEqual(mockOfficers);
  });

  it("starts in loading state", () => {
    const { result } = renderHook(() => useOfficers(), {
      wrapper: createWrapper(),
    });

    expect(result.current.isLoading).toBe(true);
  });
});