<template>
    <div class="cell"
         @mouseenter="hover = true"
         @mouseleave="hover = false">

        <q-select :hide-dropdown-icon="!hover"
                  borderless
                  v-model="newstatus"
                  @update:model-value="updatetask()"
                  :options="allStatusDropdownOptions"
                  dense
                  emit-value>

            <template v-slot:option="scope">
                <q-item v-bind="scope.itemProps">
                    <q-item-section>
                        <div>
                            <q-icon name="o_check"
                                    size="16px"
                                    :style="{visibility: scope.opt.category == (newstatus.id)
                                                                                                                        ? 'visible'
                                                                                                                        : 'hidden'}" />
                            <q-badge rounded :color="scope.opt.value.color">
                                {{scope.opt.label}}
                            </q-badge>
                        </div>
                    </q-item-section>
                </q-item>
            </template>
            <template v-slot:selected>
                <q-badge rounded
                         :color="newstatus.color ?? 'primary'"
                         v-if="newstatus != null">
                    {{newstatus.name ?? ''}}
                </q-badge>
            </template>

        </q-select>
    </div>
</template>

<style scoped>
    .cell {
        width: 100%;
        height: 100%;
    }
</style>

<script>
    import { mapGetters, mapActions } from 'vuex'
    export default {
        name: "StatusCell",
        emits: ["update-task"],
        props: {
            status: {},
        },
        computed: mapGetters(['allStatusDropdownOptions']),
        created() {
            this.fetchStatusTypes();
        },
        data() {
            return {
                hover: false,
                showdropdown: false,
                newstatus: this.status,
            }
        },
        methods: {
            updatetask() {
                this.$emit("update-task", this.newstatus);
            },
            ...mapActions(['fetchStatusTypes']),
        },
        updated() {
            this.newstatus = this.status;
        }
    }
</script>