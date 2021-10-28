<template>
  <div class="reply row bg-dark">
    <div class="col-1">
      <q-avatar color="red" text-color="white" size="35px">M</q-avatar>
    </div>
    <div class="col-11">
      <div class="column">
        <div class="col" ref="inputtext">
          <q-input
            class="inputbox"
            outlined
            dense
            v-model="inputval"
            @focus="focusTextArea()"
            @blur="blurTextArea()"
            type="textarea"
            placeholder="Ask a question or post an update..."
          />
        </div>
        <div class="reply-footer row float-right">
          <a
            style="
              margin-right: 20px;
              font-size: 12px;
              color: rgb(255, 255, 255, 0.3);
            "
            >Collaborators</a
          >

          <div id="collab-section">
            <q-avatar
              class="contributorIcons"
              color="yellow"
              text-color="black"
              size="24px"
              >MC</q-avatar
            >
            <q-avatar
              class="contributorIcons"
              color="yellow"
              text-color="black"
              size="24px"
              >ED</q-avatar
            >
            <q-avatar
              class="contributorIcons"
              color="yellow"
              text-color="black"
              size="24px"
              >D</q-avatar
            >
          </div>
          <q-btn icon="o_add" disable flat rounded dense />

          <q-space />
          <q-btn icon="o_notifications" dense no-caps flat label="Leave task" />
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
.reply {
  padding: 5px 0px 0px 0px;
}

.reply-footer {
  min-height: 40px;
  margin-top: 15px;
  align-items: center;
}

.contributorIcons {
  margin-right: 4px;
}

.inputbox {
  min-height: 50px;
}

.expanded {
  min-height: 200px;
}
</style>

<script>
import { computed, ref, onMounted } from "vue";
export default {
  name: "DiscussionReply",
  setup() {
    const heightStorage = ref(0);
    const inputtext = ref(null);
    const inputval = ref("");

    const textAreaElement = computed(() => {
      return inputtext?.value?.querySelector("textarea");
    });

    const focusTextArea = () => {
      if (textAreaElement.value != null) {
        heightStorage.value = textAreaElement.value.style.height;
        textAreaElement.value.style.height = "100px";
      }
    };

    const blurTextArea = () => {
      if (textAreaElement.value != null) {
        textAreaElement.value.style.height = heightStorage.value;
      }
    };

    onMounted(() => {
      if (textAreaElement.value != null) {
        console.log("!");
        textAreaElement.value.style.height = "50px";
      }
    });

    return {
      heightStorage,
      inputval,
      inputtext,
      textAreaElement,
      focusTextArea,
      blurTextArea,
    };
  },
};
</script>
