import { useMutation, useQueryClient } from "@tanstack/react-query";
import type { UseMutationResult } from "@tanstack/react-query";
import { deleteOfficer } from "@/lib/api-client";
import { OFFICERS_QUERY_KEY } from "./useOfficers";

export function useDeleteOfficer(): UseMutationResult<void, Error, string> {
  const queryClient = useQueryClient();

  return useMutation<void, Error, string>({
    mutationFn: (id: string): Promise<void> => deleteOfficer(id),
    onSuccess: (): void => {
      void queryClient.invalidateQueries({ queryKey: OFFICERS_QUERY_KEY });
    },
  });
}
