import type { Meta, StoryObj } from "@storybook/react";
import { Modal } from "@/components/ui/Modal";

const meta: Meta<typeof Modal> = {
  title: "UI/Modal",
  component: Modal,
  tags: ["autodocs"],
  parameters: {
    layout: "centered",
  },
};

export default meta;

type Story = StoryObj<typeof Modal>;

export const Open: Story = {
  args: {
    isOpen: true,
    onClose: () => {},
    title: "Sample Modal",
    children: (
      <p className="text-sm text-slate-600 dark:text-slate-400">
        This is modal content. You can put any React node here.
      </p>
    ),
  },
};